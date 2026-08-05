## Proje Tanimi
Burasi projemizin api tarafi olacak kullanici ile dogrudan iletisimde olacak olan katmanimiz 
Bu katmanda kullanici bir istekte bulundugu zaman bu istek alinir ve turune uygun olacak sekilde 
alt katmanimiza (application katmani) gonderilir
## Kullanilan Kutuphaneler
Projenin bu katmaninda kullancagimiz kutuphaneler agirlikli olarak bizim gelistirme surecimizi kolaylastirmak
uzerine olacak kutuphaneler. Projeyi klonladiginda muhtemelen paketler
otomatik olarak kurulacak ama kurulmazsa nasil kurulabilecegine asagidan ulasabilirsin yeni paket ekledigimde 
buraya ekleme yapmayi dusunuyorum, senin de ekledigin paketleri nasil kullanabilecegimizden bahsetmen isimizi 
cok daha kolaylastiracaktir diye dusunuyorum 
### OpenAPI 
openapi bizim projede olusturdugumuz controllerlari, endpointleri okuyarak bize gorsellestirme imkani sunar. 
openapi tek basina yeterli olmadigi icin bir diger kutuphanemiz 

OpenAPI kurulumu icin terminal acip asagidaki kodu kopyala yapistir yapabilirsin

`dotnet add package Microsoft.AspNetCore.OpenApi`
### Scalar 
scalar openapi tarafindan tespit edilen endpointleri gorsel olarak test etmemize, kimlik dogrulama 
vb isler icin bize kolaylik saglar. Alternatifi olarak swagger da kullanilabilir ama onun jwt destegi 
bu kadar yeterli olmayabiliyor eklemek istersen solution explorer icinden projeye sag tiklayip manage nuget packages 
diyip oradan swaggeri secerek ekleyebilirsin (sahsen ben scalari daha kolay buluyorum (Serafettin)) 
Scalar arayuzune erismek icin projeyi calistirdiktan sonra tarayiciya giderek asagidaki adresi arayarak
ulasabilirsin.

`http://localhost:5286/scalar`

nuget paketlerinden bulamazsan terminalden yukleyebilirsin

`dotnet add package Scalar.AspNetCore`

### FluentValidation
fluent validation apiye gelen isteklerin istedigimiz formata uygun olup olmadigini kontrol etmemizi saglayan
donus turlerini kendisi ayarlayarak bizim icin kolaylik saglayan bir pakettir.

### BCRYPT 
bcrypt sifrelerin veritabanina kaydedilirken hashlenmesini saglayan ve kullanici giris yapmak istediginde de 
kaydedilen hash ile kullanicin giris yaparken kullandigi sifrenin hash ini karsilastirarak giris yapip 
yapmamasina izin vermemizi saglayan bir pakettir. 