#include <iostream>
using namespace std;
//namespace  Miracle
//{

//}

 int main()
{
    cout<<"Hello World.\n";
    //函数指针
    void (*fp)();
    fp = func;
    (*fp)();
    void (*fp2)() = func;
    (*fp2)();
}
void func()
 {
     cout<<"func() called ....\n";

 }

