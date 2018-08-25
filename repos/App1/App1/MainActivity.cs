using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;

namespace App1
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        double a, b, c, ans;
        EditText editText;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            Button button1 = FindViewById<Button>(Resource.Id.button1);
            Button button2 = FindViewById<Button>(Resource.Id.button2);
            Button button3 = FindViewById<Button>(Resource.Id.button3);
            Button button4 = FindViewById<Button>(Resource.Id.button4);
            Button button5 = FindViewById<Button>(Resource.Id.button5);
            Button button6 = FindViewById<Button>(Resource.Id.button6);
            Button button7 = FindViewById<Button>(Resource.Id.button7);
            Button button8 = FindViewById<Button>(Resource.Id.button8);
            Button button9 = FindViewById<Button>(Resource.Id.button9);
            Button buttonadd = FindViewById<Button>(Resource.Id.buttonadd);
            Button buttonsub = FindViewById<Button>(Resource.Id.buttonsub);
            Button buttonmul = FindViewById<Button>(Resource.Id.buttonmul);
            Button buttondiv = FindViewById<Button>(Resource.Id.buttondiv);
            Button buttondot = FindViewById<Button>(Resource.Id.buttondot);
            Button buttonequal = FindViewById<Button>(Resource.Id.buttonequal);
            Button button0 = FindViewById<Button>(Resource.Id.button0);
            Button buttonc = FindViewById<Button>(Resource.Id.buttonc);
            editText = FindViewById<EditText>(Resource.Id.editText1);

            button1.Click += Button1_Click;
            button2.Click += Button2_Click;
            button3.Click += Button3_Click;
            button4.Click += Button4_Click;
            button5.Click += Button5_Click;
            button6.Click += Button6_Click;
            button7.Click += Button7_Click;
            button8.Click += Button8_Click;
            button9.Click += Button9_Click;
            buttonadd.Click += Buttonadd_Click;
            buttonsub.Click += Buttonsub_Click;
            buttonmul.Click += Buttonmul_Click;
            buttondiv.Click += Buttondiv_Click;
            buttondot.Click += Buttondot_Click;
            buttonequal.Click += Buttonequal_Click;
            button0.Click += Button0_Click;
            buttonc.Click += Buttonc_Click;
            
        }

        private void Button0_Click(object sender, System.EventArgs e)
        {
            editText.SetText(0);
            //throw new System.NotImplementedException();
        }

        private void Buttonequal_Click(object sender, System.EventArgs e)
        {
            b =double.Parse(editText.Text);
            if (c == 1)
            { ans = a + b; }
            else if (c == 2)
            { ans = a - b; }
            else if (c == 3)
            { ans = a * b; }
            else if (c == 4)
            { ans = a / b; }
            editText.SetText(int.Parse(ans.ToString()));
            //  throw new System.NotImplementedException();
        }

        private void Buttondot_Click(object sender, System.EventArgs e)
        {
            editText.SetText(int.Parse("."));
        //    throw new System.NotImplementedException();
        }

        private void Buttondiv_Click(object sender, System.EventArgs e)
        {

            a = double.Parse(editText.Text);
            editText.SetText(0);
            c = 4;

            //throw new System.NotImplementedException();
        }

        private void Buttonmul_Click(object sender, System.EventArgs e)
        {

            a = double.Parse(editText.Text);
            editText.SetText(0);
            c = 3;
            //throw new System.NotImplementedException();
        }

        private void Buttonsub_Click(object sender, System.EventArgs e)
        {

            a = double.Parse(editText.Text);
            editText.SetText(0);
            c = 2;
            //throw new System.NotImplementedException();
        }

        private void Buttonadd_Click(object sender, System.EventArgs e)
        {
           a=double.Parse(editText.Text);
            editText.SetText(0);
            c = 1;
           
          //  throw new System.NotImplementedException();
        }

        private void Buttonc_Click(object sender, System.EventArgs e)
        {
            a = b = c = ans = 0;
            editText.SetText(0);

        //    throw new System.NotImplementedException();

        }

       
        private void Button9_Click(object sender, System.EventArgs e)
        {
            editText.Text += "9";
            //throw new System.NotImplementedException();
        }

        private void Button8_Click(object sender, System.EventArgs e)
        {
            editText.Text += "8";
            //throw new System.NotImplementedException();
        }

        private void Button7_Click(object sender, System.EventArgs e)
        {
            editText.Text += "7";
            //throw new System.NotImplementedException();
        }

        private void Button6_Click(object sender, System.EventArgs e)
        {
            editText.Text += "6";
            //throw new System.NotImplementedException();
        }

        private void Button5_Click(object sender, System.EventArgs e)
        {
            editText.Text += "5";
            //throw new System.NotImplementedException();
        }

        private void Button4_Click(object sender, System.EventArgs e)
        {
            editText.Text += "4";
            //throw new System.NotImplementedException();
        }

        private void Button3_Click(object sender, System.EventArgs e)
        {
            editText.Text += "3";
            //throw new System.NotImplementedException();
        }

        private void Button2_Click(object sender, System.EventArgs e)
        {
            editText.Text += "2";
            //throw new System.NotImplementedException();
        }

        private void Button1_Click(object sender, System.EventArgs e)
        {
            Toast.MakeText(this, "Hello from ", ToastLength.Long).Show();
            editText.Text += "1";
            //throw new System.NotImplementedException();
        }

        //[Java.Interop.Export("Button1click")]
        //public void Button1click(View v)
       // {
            //int text = 123;
           //ToastLength duration = (ToastLength)int.Parse("1000");
            //Toast.MakeText(ApplicationContext, text, duration);
         //   
        //}
    }
    
}

