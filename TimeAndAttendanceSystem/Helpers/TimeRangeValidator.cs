using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeAndAttendanceSystem.Helpers
{
    public class TimeRangeValidator
    {
        private void HighlightControl(Control control, bool highlight)
        {
            control.ForeColor = highlight ? Color.LightCoral : SystemColors.Window;
        }
        // Validate a single time range (From < To)
        public bool ValidateTimeRange(DateTimePicker from, DateTimePicker to, out string errorMessage)
        {
            if (from.Value.TimeOfDay > to.Value.TimeOfDay)
            {
                errorMessage = $"'{from.Name}' time must be before '{to.Name}' time.";
                HighlightControl(from, true);
                return false;
            }
            HighlightControl(from, false);

            errorMessage = string.Empty;
            return true;
        }

        // Validate if two time ranges overlap
        public bool ValidateNoOverlap(DateTimePicker time1From, DateTimePicker time1To, out string errorMessage)
        {
            TimeSpan day1FromTime = time1From.Value.TimeOfDay;
            TimeSpan day1ToTime = time1To.Value.TimeOfDay;

            if (DoTimeRangesOverlap(day1FromTime, day1ToTime))
            {
                errorMessage = "Time ranges conflict. Please adjust the values.";
                return false;
            }

            errorMessage = string.Empty;
            return true;
        }

        // Helper method to check if two time ranges overlap
        private bool DoTimeRangesOverlap(TimeSpan range1From, TimeSpan range1To)
        {
            return range1From > range1To;
        }

        public bool ValidateTimeRangeAndOverlap(DateTimePicker from, DateTimePicker to, out string errorMessage)
        {
            // Validate if the time range is valid (From < To)
            if (!ValidateTimeRange(from, to, out errorMessage))
            {
                return false; // Return false if the time range is invalid
            }

            // Validate if the time range overlaps with a fixed range
            if (!ValidateNoOverlap(from, to, out errorMessage))
            {
                return false; // Return false if there is an overlap
            }

            // If both validations pass, return true
            errorMessage = string.Empty;
            return true;
        }
    }
}
