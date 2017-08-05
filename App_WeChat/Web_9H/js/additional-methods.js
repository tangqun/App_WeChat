$.validator.addMethod("mobileCH", function (value, element) {
    return this.optional(element) || /0?(13|14|15|18)[0-9]{9}/.test(value);
}, "请输入有效的手机号码");