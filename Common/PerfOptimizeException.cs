using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Runtime.Serialization;

namespace Common
{
    public class PerfOptimizeException : ApplicationException
    {
        private string _Message;
        private Hashtable _Params;

       public PerfOptimizeException() :  this((string) null, (Exception) null)
       {
        
       }

       public PerfOptimizeException(string message) : this(message, null)
       {

       }
      protected PerfOptimizeException(SerializationInfo info, StreamingContext context) : base(info, context)
      {
        this._Message = "未指定的异常.";
        this._Message = base.Message;
      }

     public PerfOptimizeException(string message, Exception innerException) : base(null, innerException)
     {
        this._Message = "未指定的异常.";
        if ((message != null) && (message != string.Empty))
        {
            this._Message = message;
        }
     }

    public PerfOptimizeException(string message, Exception innerException, Hashtable paramsvalue) : this(message, null)
    {
        if (paramsvalue != null)
        {
            this._Params = paramsvalue;
        }
    }

    public PerfOptimizeException(string format, Exception innerException, params object[] args) : base(null, innerException)
    {
        this._Message = "未指定的异常.";
        try
        {
            string str = string.Format(format, args);
            this._Message = str;
        }
        catch (ArgumentNullException)
        {
            StringBuilder builder = new StringBuilder();
            string str2 = "对返回的异常信息格式化时出现错误, format 或 args 为空引用\r\n";
            string str3 = string.Empty;
            if (format != null)
            {
                str3 = format + "\r\n";
            }
            else
            {
                str3 = "null\r\n";
            }
            string str4 = string.Empty;
            if (args != null)
            {
                StringBuilder builder2 = new StringBuilder();
                builder2.Append("{\r\n");
                foreach (object obj2 in args)
                {
                    builder2.Append("\t");
                    builder2.Append(obj2.ToString());
                    builder2.Append("\r\n");
                }
                builder2.Append("\r\n}");
                str4 = builder2.ToString() + "\r\n";
            }
            else
            {
                str4 = "null\r\n";
            }
            builder.Append(str2);
            builder.Append("format:\r\n");
            builder.Append(str3);
            builder.Append("args:\r\n");
            builder.Append(str4);
            this._Message = builder.ToString();
        }
        catch (FormatException)
        {
            StringBuilder builder3 = new StringBuilder();
            string str5 = "对返回的异常信息格式化时出现错误, format 无效, 或用于指示要格式化的参数的数字小于零, 或者大于等于 args 数组的长度\r\n";
            string str6 = string.Empty;
            str6 = format + "\r\n";
            string str7 = string.Empty;
            StringBuilder builder4 = new StringBuilder();
            builder4.Append("{\r\n");
            foreach (object obj3 in args)
            {
                builder4.Append("\t");
                builder4.Append(obj3.ToString());
                builder4.Append("\r\n");
            }
            builder4.Append("\r\n}");
            str7 = builder4.ToString() + "\r\n";
            builder3.Append(str5);
            builder3.Append("format:\r\n");
            builder3.Append(str6);
            builder3.Append("args:\r\n");
            builder3.Append(str7);
            this._Message = builder3.ToString();
        }
    }


       public override string Message
       {
           get
           {
               return this._Message;
           }
       }

       public Hashtable Params
       {
           get
           {
               return this._Params;
           }
           set
           {
               this._Params = value;
           }
       }

    }
}
