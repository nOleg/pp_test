# pp_test

Добрый день.

 Код написан не на максималках.
Основные функции реализованы, на уровне достаточном для определения базовых знаний.

Исходники по адресу https://github.com/nOleg/pp_test

Также поднят инстанс  в Docker по адресу http://45.8.248.108

Все заказы:
curl --request GET \
  --url http://45.8.248.108/order/all \
  --header 'Content-Type: application/json'

Добавление заказа:
curl --request POST \
  --url http://45.8.248.108/order/add \
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
  --url 'http://45.8.248.108/order/delete?id=2'

Все активные постаматы:
curl --request GET \
  --url http://45.8.248.108/postamat/all \
  --header 'Content-Type: application/json'

Выбор постамата по номеру:
curl --request GET \
  --url 'http://45.8.248.108/postamat/get?id=2233-112' \
  --header 'Content-Type: application/json'


Всё это на базе SQLite.
Посмотрите и тогда 13 октября удалю инстанс и репозиторий. 





