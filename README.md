# Интернет магазин смартфонов
## Основные требования
Веб приложение предназначено для просмотра информации о различных моделях смартфонов, а также для дальнейшей покупки.
Полльзователи приложения разделены на 3 группы со своими правами.
1. Покупатель. Он может просматривать каталог товаров, добавлять понравившиеся товары в корзину, а также совершать покупки.
2. Продавец-консультант. Обладает теми же правами, что и покупатель, а также может изменять информацию о наличии товара.
3. Старший менеджер. Обладает теми же правами. что и продавец-консультант, а также может добавлять новые модели или удалять из каталога снятые с продажи.
## Регистрация пользователей
Для регистрации покупателю необходимо будет указать ФИО, номер телефона, город или населённый пункт, восьмизначный пароль, а также почту и дату рождения опционально (для акционных рассылок и персональных скидок). Для сотрудника при регистрации информация о почте и дате рождения будет обязательной, также необходимо будет указать адрес офиса или оффлайн магазина, в котором числится сотрудник. 

При выходе из системы пользователь будет восприниматься как незаригестрированный. Незарегестрированные пользователи могут просматривать каталог, а при попытке оформления заказа им будет предложена регистрация.

Авторизация происходит посредством указания логина в виде номера телефона или почты, а также пароля.

## Работа с записями
Пользователи, в зависимости от типа, могут работать с данными приложения различными способами:
1. Просмотр списка записей (INDEX). Все пользователи могут просматривать список доступных доступных моделей телефонов, а также фильтровать по названию, цене, наличию и основным характеристикам, такими, как производитель, объём внутренней и оперативной памяти, размер экрана. процессор и разрешению основного модуля.
2. Создание записи (CREATE). Старший менеджер может добавить новую модель, указав характеристики, описанные выше.
3. Просмотр деталей записи (READ). Все пользователи могут просматривать информацию о смартфонах и своих заказах, текущих и выполненных.
4. Редактирование записи (UPDATE). Сотрудники имеют право изменять информацию о наличии, а старшие менеджеры изменять информацию о цене и при необходимости основые характеристики.
5. Удаление записи (DELETE). Старшие менедеры имеют право удалять записи товаров, снятых с продажи.

