﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cudo.Entities;
using Cudo.Business;
using web.ailipay;

namespace web.Users
{
    public partial class onlinerecharge : BasePage
    {
        RechargeorderBLL bll = new RechargeorderBLL();
        private string orderno = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            base.IsLogin(); 
            orderno = base.GetStringValue("orderno");
            if (!IsPostBack)
            {
                PageInit();
            }
        }

        private void PageInit()
        {
            if (orderno != string.Empty)
            {
                Rechargeorder item = bll.GetItem(orderno);
                if (item != null)
                {
                    hidden_orderno.Value = item.OrderNo;
                    txtorderprice.Value = item.OrderPrice.ToString();
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string out_trade_no = "";
            if (hidden_orderno.Value != string.Empty)
            {
                out_trade_no = hidden_orderno.Value;
            }
            else
            {
                out_trade_no = DateTime.Now.ToString("yyyyMMddHHmmss") + new Random().Next(10, 100);
                Rechargeorder item = new Rechargeorder();
                item.OrderNo = out_trade_no;
                item.TradeNo = "";
                item.Payment = "支付宝";
                item.OrderPrice = Convert.ToDecimal(txtorderprice.Value.Trim());
                item.UserId = (Session["cudoUser"] as UserInfo).Id;
                bll.AddItem(item);
            }

            ////////////////////////////////////////////请求参数////////////////////////////////////////////

            //必填参数//

            //请与贵网站订单系统中的唯一订单号匹配
            //string out_trade_no = DateTime.Now.ToString("yyyyMMddHHmmss") + new Random().Next(10, 100);
            //订单名称，显示在支付宝收银台里的“商品名称”里，显示在支付宝的交易管理的“商品名称”的列表里。
            string subject = "107饭在线充值";
            //订单描述、订单详细、订单备注，显示在支付宝收银台里的“商品描述”里
            string body = "107饭在线充值";
            //订单总金额，显示在支付宝收银台里的“应付总额”里
            string total_fee = txtorderprice.Value.Trim();

            //扩展功能参数——默认支付方式//

            //默认支付方式，代码见“即时到帐接口”技术文档
            string paymethod = "";
            //默认网银代号，代号列表见“即时到帐接口”技术文档“附录”→“银行列表”
            string defaultbank = "";

            //扩展功能参数——防钓鱼//

            //防钓鱼时间戳
            string anti_phishing_key = "";
            //获取客户端的IP地址，建议：编写获取客户端IP地址的程序
            string exter_invoke_ip = "";
            //注意：
            //请慎重选择是否开启防钓鱼功能
            //exter_invoke_ip、anti_phishing_key一旦被设置过，那么它们就会成为必填参数
            //建议使用POST方式请求数据
            //示例：
            //exter_invoke_ip = "";
            //Service aliQuery_timestamp = new Service();
            //anti_phishing_key = aliQuery_timestamp.Query_timestamp();               //获取防钓鱼时间戳函数

            //扩展功能参数——其他//

            //商品展示地址，要用http:// 格式的完整路径，不允许加?id=123这类自定义参数
            //string show_url = "http://www.xxx.com/myorder.aspx";
            //自定义参数，可存放任何内容（除=、&等特殊字符外），不会显示在页面上
            string extra_common_param = "";
            //默认买家支付宝账号
            string buyer_email = "";

            //扩展功能参数——分润(若要使用，请按照注释要求的格式赋值)//

            //提成类型，该值为固定值：10，不需要修改
            string royalty_type = "";
            //提成信息集
            string royalty_parameters = "";
            //注意：
            //与需要结合商户网站自身情况动态获取每笔交易的各分润收款账号、各分润金额、各分润说明。最多只能设置10条
            //各分润金额的总和须小于等于total_fee
            //提成信息集格式为：收款方Email_1^金额1^备注1|收款方Email_2^金额2^备注2
            //示例：
            //royalty_type = "10";
            //royalty_parameters = "111@126.com^0.01^分润备注一|222@126.com^0.01^分润备注二";

            ////////////////////////////////////////////////////////////////////////////////////////////////

            //把请求参数打包成数组
            SortedDictionary<string, string> sParaTemp = new SortedDictionary<string, string>();
            sParaTemp.Add("payment_type", "1");
            //sParaTemp.Add("show_url", show_url);
            sParaTemp.Add("out_trade_no", out_trade_no);
            sParaTemp.Add("subject", subject);
            sParaTemp.Add("body", body);
            sParaTemp.Add("total_fee", total_fee);
            sParaTemp.Add("paymethod", paymethod);
            sParaTemp.Add("defaultbank", defaultbank);
            sParaTemp.Add("anti_phishing_key", anti_phishing_key);
            sParaTemp.Add("exter_invoke_ip", exter_invoke_ip);
            sParaTemp.Add("extra_common_param", extra_common_param);
            sParaTemp.Add("buyer_email", buyer_email);
            sParaTemp.Add("royalty_type", royalty_type);
            sParaTemp.Add("royalty_parameters", royalty_parameters);

            //构造即时到帐接口表单提交HTML数据，无需修改
            Service ali = new Service();
            string sHtmlText = ali.Create_direct_pay_by_user(sParaTemp);
            Response.Write(sHtmlText);
        }
    }
}
