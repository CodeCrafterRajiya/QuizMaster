namespace quezemasterNew.CommonFunctional
{
    public class CommonHelperData
    {
        internal DateTime? MapDateTimeValue(object DataObject, DateTime DefaultValue)
        {
            if(DataObject !=DBNull.Value)
            {
                if(DateTime.TryParse(DataObject.ToString(),out DateTime Result))
                {
                    return Result;
                }
            }
            return DefaultValue;
        }

        internal int MapIntegerValue(object DataObject, int DefaultValue = 0)
        {
            try
            {// Check if the dataObject is not DBNull
                if (DataObject != DBNull.Value)
                {
                    // Try to convert the dataObject to a string and then parse it to an integer
                    if (int.TryParse(DataObject.ToString(), out int Result))
                    {
                        return Result;// Return the parsed integer
                    }
                }
                // If the dataObject is DBNull or parsing fails, return the default value
                return DefaultValue;
            }
            catch(Exception ex)
            {

            }
            return DefaultValue;
        }

    }
}

