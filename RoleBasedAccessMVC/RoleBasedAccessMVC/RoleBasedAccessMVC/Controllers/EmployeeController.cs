using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using RoleBasedAccess.Model;

namespace RoleBasedAccessMVC.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        [Authorize(Roles="Trainee")]
        public ActionResult EmployeeViewRemark(int ?page)
        {
            int pageNumber = (page ?? 1);
            string employeeId=Session["employeeId"].ToString();
            PaginationRemarkListResponse remarkListResponse = PaginationRemarkListResponse.GetRemarkList(employeeId,""+pageNumber,"3");
            ViewData["RemarkList"]=remarkListResponse.PaginationRemarkList;
            if (string.Equals(remarkListResponse.Status.StatusCode, "200", StringComparison.OrdinalIgnoreCase) == false)
            {

            }
            int pageSize = 3;
            RemarkCountResponse remarkCount=RemarkCountResponse.GetRemarkCount(employeeId);
            var list = new StaticPagedList<Remark>(remarkListResponse.PaginationRemarkList, pageNumber, pageSize, remarkCount.RemarkCount);
            return View(list);
        }
    }
}
