sln -> solution 
السلوشن الواحد ممكن يكون فيه كذا بروجيكت من انواع مختلفهه ب لغات مختلفه
لو حابب تستخدم مثلا library في بروجيكت لازم تعمل ريفيرينس بينهم ممكن تعملهم بخطوتين امال تضغط علي ال file double click و بعدين تكتبها manually
او right click هتلاقي references  و اعمل check و اعمل save
![[Pasted image 20250726093624.png]]
ولو البروجيكت متقسم في files كتير لازم يكون في main method واحده فقط في نفس البروجيكت ودا ال entry point ال بيبدأمن عندها عشان كدا لازم تكون واحده فقط

```cs
static void Main(string[] args ){
	/* body */
}
```

```cs
console.write(); // print on console without newline
console.writeline(); // print on console with new line
```
----------------------------------------
solution as a container
so can include many project and each project have a main method , and you can choose which project you will build by 
لو عاوز تعرف ال IDE انهي program ال في sln عشان ت run هتلاقيه **bold** 
لو عاوز تغيره Right Click then choose set as startup project  و بالتالي كدا بعد لما تعمل build هيعملل للهيكون عليه bold

![[Pasted image 20250726095743.png]]

---------------------------------------

لو في بروجيكت في classes كتيره و متشابهه ايه الحل ؟
> عن طريق ال namespaces عشان بيكون الموضوع اكثر نظام 

namespace as a folder and you order you classes in it
steps : 
	1- create a class library
	2-use namespace for organize 
```cs
namespace filename.auto{
	namespace asia {
		namespace japan{
			public class toyota {
		
			}
		}
		namespace sKorea {
			public class Hyundai{
		
			}
			public class kia{
		
			}
		}
	}
}

// after add refernece to use this classes
// must two file work on same .net version for compatibility
filename.auto.asia.japan.toyota;
// هل معقول كل مره هحب استخدمهم اعمل كل ال الpath دا
// beginning of the file
using filename.auto.asia
//then 
japan.toyota

```

* الغايه هي ان يكون البيئه تنظيميه عشان ممكن البروجيكت مكون من files كتير.
* احيانا بيكون ال one file في مكانين مختلفين بيعنوا اشياء مختلفه
مثال الموظف في HR بيكون ليه معلومات مختلفه عن الموظف لو في media .
الوظيفه واحده ولكن بختلاف المكان بيختلف المعني

==good practice : make each class in file  ==

------------------------------------
framework
هوا frame كبيره ضمه كذا حاجه مع بعض
![[Pasted image 20250726094503.png]]


ال class library مش لازم يكون عنده main method عشان انت مش بتعمله run انت فقط بتربطه with program to execute
