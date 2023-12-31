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
    public partial class ShowClassInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string text1 = classNumber.Text.Trim();
            string text2 = className.Text.Trim();
            string text3 = classMajor.Text.Trim();
            if("".Equals(text1) && "".Equals(text2) && "".Equals(text3))
            {
                Response.Write("<script>alert('请至少输入一条信息吧！');</script>");
            }
            else
            {
                string sqlStr = "select * from classinfo ";
                sqlStr += "where classid = '" + text1 + "' ";
                sqlStr += "or classname = '" + text2 + "' ";
                sqlStr += "or classmajor =  '" + text3 + "' ";

                DataSet myds = Common.dataSet(sqlStr);

                if (myds.Tables.Count == 1 && myds.Tables[0].Rows.Count == 0)
                {
                    Response.Write("<script>alert('未查询到相关信息！');</script>");
                }
                else
                {
                    Response.Write("<script>alert('已找到的相关信息！');</script>");
                    RpClassInfo.Visible = false;
                    Repeater1.Visible = true;
                    Repeater1.DataSource = myds;
                    Repeater1.DataBind();
                    Button1.Visible = true;
                }
                

            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            RpClassInfo.Visible = true;
            Repeater1.Visible = false;
        }
    }
}