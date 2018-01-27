using System;
using System.Collections.Generic;
using Android.Content;
using Android.Views;
using Android.Widget;
using Com.Github.Library.Bubbleview;
using QnAMakerAndroidDemo.Models.Responses;
using System.Linq;
using QnAMakerAndroidDemo.Models;

namespace QnAMakerAndroidDemo.Adapters
{
    public class CustomAdapter : BaseAdapter
    {
        private List<ModelMessageData> ListChatModel;
        private Context Context;
        private LayoutInflater Inflater;

        public CustomAdapter(List<ModelMessageData> listchatmodel, Context context)
        {
            ListChatModel = listchatmodel;
            Context = context;
            Inflater = (LayoutInflater)context.GetSystemService(Context.LayoutInflaterService);
        }

        public override int Count
        {
            get
            {
                return ListChatModel.Count;
            }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;
            if (view == null)
            {
                if (ListChatModel[position].IsSend)
                {
                    view = Inflater.Inflate(Resource.Layout.list_item_message_send, null);
                }
                else
                {
                    view = Inflater.Inflate(Resource.Layout.list_item_message_recv, null);
                }

                BubbleTextView bubbleTextView = view.FindViewById<BubbleTextView>(Resource.Id.text_message);
                bubbleTextView.Text = (ListChatModel[position].Message);
            }

            return view;
        }
    }
}