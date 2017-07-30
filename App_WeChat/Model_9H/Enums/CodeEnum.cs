using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model_9H
{
    public enum CodeEnum
    {
        系统异常 = -1,
        成功 = 0,
        失败 = 1,

        // 上传图片
        文件集合为空 = 400001,
        文件大小超限 = 400002,

        // 会员卡
        Code解码失败 = 401001,
    }
}
