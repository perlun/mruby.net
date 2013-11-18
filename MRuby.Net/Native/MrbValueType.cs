namespace MRuby.Net.Native
{
    public enum MrbValueType
    {
        False = 0,
        Free,        /*   1 */
        True,        /*   2 */
        Fixnum,      /*   3 */
        Symbol,      /*   4 */
        Undef,       /*   5 */
        Float,       /*   6 */
        Cptr,        /*   7 */
        Object,      /*   8 */
        Class,       /*   9 */
        Module,      /*  10 */
        IClass,      /*  11 */
        SClass,      /*  12 */
        Proc,        /*  13 */
        Array,       /*  14 */
        Hash,        /*  15 */
        String,      /*  16 */
        Range,       /*  17 */
        Exception,   /*  18 */
        File,        /*  19 */
        Env,         /*  20 */
        Data,        /*  21 */
        Fiber,       /*  22 */
        MaxDefine    /*  23 */
    };
}