using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BAL;

namespace Project.Controllers
{
    [Route("IOC")]
    public class IOCController : Controller
    {
        #region Initializations

        private readonly IRandomNumber _randomNumber = null;

        #endregion

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        /// <param name="randomNumber"></param>
        public IOCController(IRandomNumber randomNumber)
        {
            _randomNumber = randomNumber;
        }
        #endregion

        #region Controller Actions
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            string str = _randomNumber.RandomPassword();
            ViewData["RandomPassword"] = str;
            ViewData["Title"] = "IOC-Index";
            return View();
        }
        #endregion

    }
}