using System;
using Syncfusion.iOS.DataForm;
using UIKit;

namespace DateTimeOffsetConverter
{
    public partial class ViewController : UIViewController
    {
        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }
        SfDataForm dataForm;
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            dataForm = new SfDataForm();
            dataForm.DataObject = new DateInfo();
            dataForm.BackgroundColor = UIColor.White;
            this.View = dataForm;
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
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
