# pp_test

Добрый день.

 Код написан не на максималках.
Основные функции реализованы, на уровне достаточном для определения базовых знаний.

Исходники по адресу https://github.com/nOleg/pp_test

Также поднят инстанс  в Docker по адресу http://45.8.248.108

Все заказы:
curl --request GET \
   --url http://45.8.248.108/Order/AllOrders \
  --header 'Content-Type: application/json'

Добавление заказа:
curl --request POST \
  --url http://45.8.248.108/Order/AddOrder \
  --header 'Content-Type: application/json' \
  --data '
  {
   "statusID": 3,
   "products": [
      {
        "name": "Audi"
      },
      {
        "name": "Mercedes"
      },
      {
        "name": "Жигули"
      }
    ],
    "total": 1234.55,
    "postamaNum": "2233-113",
   	"telephone": "+7111-111-11-11",
    "fullName": "Петров Петр"
  }

Удаление заказа:
curl --request GET \
  --url 'http://45.8.248.108/Order/DeleteOrder?id=2'

Все активные постаматы:
curl --request GET \
  --url http://45.8.248.108/Postamat/GetAllPostamats \
  --header 'Content-Type: application/json'

Выбор постамата по номеру:
curl --request GET \
  --url 'http://45.8.248.108/Postamat/GetPostamatById?id=2233-112' \
  --header 'Content-Type: application/json'


Всё это на базе SQLite.







