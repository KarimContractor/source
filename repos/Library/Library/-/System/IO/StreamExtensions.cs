using System.Collections.Generic;
using System.Text;

namespace System.IO
{
	/// <summary>
	/// 
	/// </summary>
	internal static class StreamExtensions
	{
		private const int DefaultBufferSize = 4096;

		/// <summary>
		/// Copies to.
		/// </summary>
		/// <param name="input">The input.</param>
		/// <param name="output">The output.</param>
		/// <param name="buffer">The buffer.</param>
		public static void CopyTo(this Stream input, Stream output, byte[] buffer = null)
		{
			CopyTo(input, output, buffer, null);
		}

		/// <summary>
		/// Copies to.
		/// </summary>
		/// <param name="input">The input.</param>
		/// <param name="output">The output.</param>
		/// <param name="progressHandler">The progress handler.</param>
		public static void CopyTo(this Stream input, Stream output, Action<long> progressHandler)
		{
			CopyTo(input, output, new byte[DefaultBufferSize], progressHandler);
		}

		/// <summary>
		/// Copies to.
		/// </summary>
		/// <param name="input">The input.</param>
		/// <param name="output">The output.</param>
		/// <param name="buffer">The buffer.</param>
		/// <param name="progressHandler">The progress handler.</param>
		public static void CopyTo(this Stream input, Stream output, byte[] buffer, Action<long> progressHandler)
		{
			Guard.NotNull(input, "input");
			Guard.NotNull(output, "output");
			Guard.NotNull(buffer, "buffer");
			long bytesTransferred = 0;
			int bytesRead;
			while ((bytesRead = input.Read(buffer, 0, buffer.Length)) > 0)
			{
				output.Write(buffer, 0, bytesRead);
				if (progressHandler == null)
				{
					continue;
				}
				bytesTransferred += bytesRead;
				progressHandler(bytesTransferred);
			}
		}

		/// <summary>
		/// Creates a copy of the passed stream and returns the clone to position 0.
		/// </summary>
		/// <param name="source">The Stream to be copied</param>
		/// <returns>A copy of the source stream</returns>
		public static Stream CopyToNewStream(this Stream source)
		{
			Stream clone = new MemoryStream();
			CopyTo(source, clone);
			clone.Seek(0, SeekOrigin.Begin);
			return clone;
		}

		/// <summary>
		/// Reads a complete stream
		/// </summary>            
		/// <returns>The contents of the stream</returns>
		public static string ReadAll(this Stream stream, Encoding encoding = null)
		{
			if (encoding == null)
			{
				encoding = Encoding.Default;
			}
			using (StreamReader sr = new StreamReader(stream, encoding))
			{
				return sr.ReadToEnd();
			}
		}

		/// <summary>
		/// Reads all bytes from a stream and returns a byte array
		/// </summary>
		/// <param name="stream">The stream to read data from</param>
		public static byte[] ReadAllBytes(this Stream stream)
		{
			byte[] buffer = new byte[DefaultBufferSize];
			int read = 0;

			int numBytes;
			while ((numBytes = stream.Read(buffer, read, buffer.Length - read)) > 0)
			{
				read += numBytes;

				// If we've reached the end of our buffer, check to see if there's any more information
				if (read == buffer.Length)
				{
					int nextByte = stream.ReadByte();

					// End of stream? If so, we're done
					if (nextByte == -1)
					{
						return buffer;
					}

					// Nope. Resize the buffer, put in the byte we've just read, and continue
					byte[] newBuffer = new byte[buffer.Length*2];
					Array.Copy(buffer, newBuffer, buffer.Length);
					newBuffer[read] = (byte)nextByte;
					buffer = newBuffer;
					read++;
				}
			}
			// Buffer is now too big. Shrink it.
			byte[] result = new byte[read];
			Array.Copy(buffer, result, read);
			return result;
		}

		/// <summary>
		/// Reads a stream line by line
		/// </summary>            
		/// <returns>The read lines</returns>
		public static List<string> ReadLines(this Stream stream, Encoding encoding = null)
		{
			if (encoding == null)
			{
				encoding = Encoding.Default;
			}
			List<string> lines = new List<string>();
			using (StreamReader sr = new StreamReader(stream, encoding))
			{
				while (sr.Peek() >= 0)
				{
					lines.Add(sr.ReadLine());
				}
			}
			return lines;
		}

		/// <summary>
		/// 	Sets the stream cursor to the beginning of the stream.
		/// </summary>
		/// <param name = "stream">The stream.</param>
		/// <returns>The stream</returns>
		public static Stream SeekToBegin(this Stream stream)
		{
			if (stream.CanSeek == false)
			{
				throw new InvalidOperationException("Stream does not support seeking.");
			}

			stream.Seek(0, SeekOrigin.Begin);
			return stream;
		}

		/// <summary>
		/// 	Sets the stream cursor to the end of the stream.
		/// </summary>
		/// <param name = "stream">The stream.</param>
		/// <returns>The stream</returns>
		public static Stream SeekToEnd(this Stream stream)
		{
			if (stream.CanSeek == false)
			{
				throw new InvalidOperationException("Stream does not support seeking.");
			}

			stream.Seek(0, SeekOrigin.End);
			return stream;
		}

		/// <summary>
		/// Attempts to get the length of the stream. Returns -1 if the length of the stream could not be determined.
		/// </summary>
		/// <param name="stream">The stream to query.</param>
		/// <returns>The length of the stream, or -1 if the stream has an undefined length.</returns>
		public static long TryGetLength(this Stream stream)
		{
			try
			{
				return stream.Length;
			}
			catch (NotSupportedException)
			{
				return -1;
			}
		}

		/// <summary>
		/// 	Writes all passed bytes to the specified stream.
		/// </summary>
		/// <param name = "stream">The stream.</param>
		/// <param name = "bytes">The byte array / buffer.</param>
		public static void Write(this Stream stream, byte[] bytes)
		{
			stream.Write(bytes, 0, bytes.Length);
		}
	}
}