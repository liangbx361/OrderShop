// JavaScript Document

//����긨
function fansy_lldp_onm(fansy_xzdc_obj) {
    fansy_xzdc_obj.src = "/images/fw_lg_lldpbutonm.gif";
}
function fansy_lldp_out(fansy_xzdc_obj) {
    fansy_xzdc_obj.src = "/images/fw_lg_lldpbut.gif";
}

//�ύ
function fansy_submit_onm(fansy_xzdc_obj) {
    fansy_xzdc_obj.src = "/images/fw_lg_tjbutonm.gif";
}
function fansy_submit_out(fansy_xzdc_obj) {
    fansy_xzdc_obj.src = "/images/fw_lg_tjbut.gif";
}

//107�Է���ҳ ���ڶ��� ��ť�л�
function fansy_xzdc_onm(fansy_xzdc_obj) {
    fansy_xzdc_obj.src = "/images/fansy_top_xzdcbutonc.jpg";
}
function fansy_xzdc_out(fansy_xzdc_obj) {
    fansy_xzdc_obj.src = "/images/fansy_top_xzdcbut.jpg";
}

//107�Է���ҳ �������� ��ť�л�
function fansy_bzzx_onm(fansy_bzzx_obj) {
    fansy_bzzx_obj.src = "/images/fansy_top_bzzxbutonc.jpg";
}
function fansy_bzzx_out(fansy_bzzx_obj) {
    fansy_bzzx_obj.src = "/images/fansy_top_bzzxbut.jpg";
}

//ȷ���µ�
function fansy_order_onm(fansy_bzzx_obj) {
    fansy_bzzx_obj.src = "/images/btn_check_order_butonm.gif";
}
function fansy_order_out(fansy_bzzx_obj) {
    fansy_bzzx_obj.src = "/images/btn_check_order.gif";
}

//��ʾ����
function shengxs() {
    document.getElementById("sheng").style.display = "block";

    var tmobj = document.getElementById("TouMingDiv");
    tmobj.style.width = document.body.scrollWidth + "px";
    tmobj.style.height = document.body.scrollHeight + "px";
    tmobj.style.display = "block";

    var ifobj = document.getElementById("ifsheng");
    ifobj.style.width = document.body.scrollWidth + "px";
    ifobj.style.height = document.body.scrollHeight + "px";
    ifobj.style.display = "block";

}

//�رյ���
function closesdiv() {
    document.getElementById("sheng").style.display = "none";
    document.getElementById("TouMingDiv").style.display = "none";
    document.getElementById("ifsheng").style.display = "none";
}