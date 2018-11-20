using Syncfusion.XForms.DataForm;
using System;
using System.Collections.Generic;
using System.Text;

namespace DateTimeOffsetConverter
{
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

    public class DateOffsetInfo
    {
        private DateInfo dateInfo;
        public DateInfo DateInfo
        {
            get { return this.dateInfo; }
            set { this.dateInfo = value; }
        }
        public DateOffsetInfo()
        {
            dateInfo = new DateInfo();
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
