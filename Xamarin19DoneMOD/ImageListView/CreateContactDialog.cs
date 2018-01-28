using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Net;
using System.Collections.Specialized;

namespace WebRequestTutorial
{
    public class CreateContactEventArgs : EventArgs
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }

        public CreateContactEventArgs(int id, string name, string number)
        {
            ID = id;
            Name = name;
            Number = number;
        }
    }

    class CreateContactDialog : DialogFragment
    {
        private Button mButtonCreateContact;
        private EditText txtName;
        private EditText txtNumber;
        private ProgressBar mProgressBar;

        public event EventHandler<CreateContactEventArgs> OnCreateContact;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.dialog_sign_up, container, false);
            mButtonCreateContact = view.FindViewById<Button>(Resource.Id.btnCreateContact);
            txtName = view.FindViewById<EditText>(Resource.Id.txtName);
            txtNumber = view.FindViewById<EditText>(Resource.Id.txtNumber);
            mProgressBar = view.FindViewById<ProgressBar>(Resource.Id.progressBar);

            mButtonCreateContact.Click += mButtonCreateContact_Click;
            return view;
           
        }

        void mButtonCreateContact_Click(object sender, EventArgs e)
        {
            mProgressBar.Visibility = ViewStates.Visible;

            WebClient client = new WebClient();
            Uri uri = new Uri("http://staralmanaaltourism.com/CreateContact.php");
            NameValueCollection parameters = new NameValueCollection();

            parameters.Add("Name", txtName.Text);
            parameters.Add("Number", txtNumber.Text);

            client.UploadValuesCompleted += client_UploadValuesCompleted;
            client.UploadValuesAsync(uri, parameters);          
        }

        void client_UploadValuesCompleted(object sender, UploadValuesCompletedEventArgs e)
        {
            Activity.RunOnUiThread(() =>
            {
                string id = Encoding.UTF8.GetString(e.Result); //Get the data echo backed from PHP
                int newID = 0;

                int.TryParse(id, out newID); //Cast the id to an integer

                if (OnCreateContact != null)
                {
                    //Broadcast event
                    OnCreateContact.Invoke(this, new CreateContactEventArgs(newID, txtName.Text, txtNumber.Text));
                }

                mProgressBar.Visibility = ViewStates.Invisible;
                this.Dismiss();
            });
            
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle);
            base.OnActivityCreated(savedInstanceState);
            Dialog.Window.Attributes.WindowAnimations = Resource.Style.dialog_animation;
        }
    }
}