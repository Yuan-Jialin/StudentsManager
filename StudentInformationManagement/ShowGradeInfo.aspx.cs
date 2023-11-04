﻿using demon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentInformationManagement
{
    public partial class gradeInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string text1 = gradeID.Text.Trim();
            string text2 = gradeStuName.Text.Trim();
            string text3 = gradeCourse.Text.Trim();
            if ("".Equals(text1) && "".Equals(text2) && "".Equals(text3))
            {
                Response.Write("<script>alert('请至少输入一条信息吧！');</script>");
            }
            else
            {
                string sqlStr = "select * from gradeinfo ";
                sqlStr += "where gradeid = '" + text1 + "' ";
                sqlStr += "or gradestuname = '" + text2 + "' ";
                sqlStr += "or gradecourse =  '" + text3 + "' ";

                DataSet myds = Common.dataSet(sqlStr);

                if (myds.Tables.Count == 1 && myds.Tables[0].Rows.Count == 0)
                {
                    Response.Write("<script>alert('未查询到相关信息！');</script>");
                }
                else
                {
                    Response.Write("<script>alert('已找到的相关信息！');</script>");
                    RpGradeInfo.Visible = false;
                    Repeater1.Visible = true;
                    Repeater1.DataSource = myds;
                    Repeater1.DataBind();
                    Button1.Visible = true;
                }


            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            RpGradeInfo.Visible = true;
            Repeater1.Visible = false;
        }


    }
}