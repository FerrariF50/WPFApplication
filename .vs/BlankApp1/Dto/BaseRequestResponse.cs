namespace BlankApp1.Dto
{
    public class BaseRequestResponse<T>
    {
        public BaseRequestResponse()
        {

        }

        public T Body { get; set; }
        public bool HasError { get; set; }
        public string Error { get; set; }
    }
}
