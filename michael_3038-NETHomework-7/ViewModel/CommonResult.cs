namespace michael_3038EFWebAPI.ViewModel
{
    public class CommonResult<T>
    {
        public bool IsSucess { get; set; }

        public string? Message { get; set; }

        public T? Result { get; set; }

    }
}
