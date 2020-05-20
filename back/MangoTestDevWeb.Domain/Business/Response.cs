namespace MangoTestDevWeb.Domain
{
  public class Response<T>
  {
    public T Value { get; set; }

    public bool Success { get; set; }

    public Response()
    { }

    public Response(T value)
    {
      Value = value;
      Success = true;
    }
  }
}
