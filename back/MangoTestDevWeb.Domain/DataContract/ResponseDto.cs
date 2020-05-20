using System;
using System.Collections.Generic;
using System.Text;

namespace MangoTestDevWeb.Domain
{
  public class ResponseDto<T>
  {
    public T Value { get; set; }

    public bool Success { get; set; }

    public ResponseDto()
    { }

    public ResponseDto(T value)
    {
      Value = value;
      Success = true;
    }
  }
}
