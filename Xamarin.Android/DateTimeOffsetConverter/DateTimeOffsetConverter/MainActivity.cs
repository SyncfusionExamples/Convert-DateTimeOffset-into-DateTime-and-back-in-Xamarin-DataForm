using Android.App;
using Android.Widget;
using Android.OS;
using Syncfusion.Android.DataForm;
using Android.Graphics;
using System;

namespace DateTimeOffsetConverter
{
    [Activity(Label = "DateTimeOffsetConverter", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        SfDataForm dataForm;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            dataForm = new SfDataForm(this);
            dataForm.SetBackgroundColor(Color.White);
            dataForm.DataObject = new DateInfo();
            // Set our view from the "main" layout resource
            SetContentView(dataForm);

        }
    }
    public class DateInfo
    {

        private DateTimeOffset displayDate;

        [Converter(typeof(ValueConverterExt))]
        public DateTimeOffset DisplayDate
        {
            get
            {
                return displayDate;
            }
            set
            {
                displayDate = value;
            }
        }
    }

    public class ValueConverterExt : IPropertyValueConverter
    {
        public object Convert(object value)
        {
            DateTime baseTime = new DateTime(2008, 6, 19, 7, 0, 0);
            DateTime targetTime;

            var dateTimeOffset = (DateTimeOffset)value;
            dateTimeOffset = new DateTimeOffset(baseTime,
                                                TimeZoneInfo.Local.GetUtcOffset(baseTime));
            targetTime = dateTimeOffset.DateTime;
            return targetTime;
        }
        public object ConvertBack(object value)
        {
            var dateTime = (DateTime)value;
            dateTime = new DateTime(2008, 6, 19, 7, 0, 0);
            dateTime = DateTime.SpecifyKind(dateTime, DateTimeKind.Local);
            DateTimeOffset dateTimeOffset = dateTime;
            return dateTimeOffset;
        }
    }
}

