﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using arkano.common.domain;
using arkano.logic.common;
using arkano.logic.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace arkano.api.Controllers.DummyTest
{
    [Route("api/[controller]")]
    [ApiController]
    public class DummyTestController : Base.BaseController<DummyTestModel, DummyTestLogic>
    {
        //Extend controller here
    }
}