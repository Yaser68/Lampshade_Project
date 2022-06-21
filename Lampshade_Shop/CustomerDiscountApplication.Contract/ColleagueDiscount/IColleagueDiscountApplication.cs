﻿using _0_Framework.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerDiscount.Application.Contract.ColleagueDiscount
{
    public  interface IColleagueDiscountApplication
    {
        OperationResult Define(DefineColleagueDiscount command);
        OperationResult Edit(EditColleagueDiscount command);
        OperationResult Remove(long id);
        OperationResult Restore(long id);

        EditColleagueDiscount GetDetails(long id);
        List<ColleaguediscountViewModel> Search(ColleagueDiscountSearchModel searchModel);
    }
}
