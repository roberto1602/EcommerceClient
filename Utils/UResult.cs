namespace Utils
{
    public class UResult
    {
        public static Result<Target> Error<Target>(string msg, Target? res) 
        { 
            return new Result<Target>() 
            { 
                Error = false, 
                Message = msg, 
                Values = res 
            }; 
        }
        public static Result<Target> Ok<Target>(string msg, Target? res) 
        { 
            return new Result<Target>() 
            { 
                Error = true, 
                Message = msg, 
                Values = res 
            }; 
        }
    }
}