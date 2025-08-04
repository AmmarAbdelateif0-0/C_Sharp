int value can't be null
to make it store null `int?`

```cs 
int? k = null;
int m =6;
//case 1 
k=m; // true

//case 2 
m = k ; // k can be null and Error
m = (int) k ; //

// to avoid this error
if(k != Null){
	m = (int) k ;
}
// or
if(k.HasValue){
	m =K.Value;
}else{
	m=0;
}
// or
m = k.HasValue ? k.Value : 0 ;
// or
m = k ?? 0 ;
```