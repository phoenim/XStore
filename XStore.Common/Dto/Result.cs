﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XStore.Common.Dto
{
    public class Result
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }

    public class Result<T>
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public T Data { get; set; }
    }
}
