### INFRASTRUCTURE KATMANI 
bu katmanimiz veritabani ile olan baglantilarimizi yonetir. bu katmanda bulunan repositoryler
bizim veritabani kaydi sirasinda neyi nereye atadigimizi gosteren ve atamalari yapan classlardir.


### BaseRepository 
base repository her bir reposistory sinifinda tekrar kullandigimiz veritabani baglantisi islemimizi
bu sinifi inherit ederek yani miras alarak tek sefer tanimlamamiza olanak veren bir yapidir. 
kafani karistirmasin 

### AccountRepository 
account repository bizim kullanicilarimizin kaydedilmesi, giris yapmasi, mentor kaydi vb
islemlerimizi halletmek icin kullanabilecegimiz sinifimizdir. ilerde istersek tabiki bunu da mentor
repository intern repository vb olarak ayirabiliriz ama cogaldikca kafamiz karismasin diye 
simdlik bu sekilde birakiyorum. 

### RoleRepository 
ilerleyen zamanlarda admin mentor ve stajyer disinda farkli roller eklersek ve bunlarin yetkilerini vs 
duzenlemek istersek diye eklenen bir sinif sen de bakarsin eger degistirelim dersek onu komple
kaldiririz. 