#Создание заявки на ремонт
INSERT INTO repairrequests (IdRepairRequest, DateRequest, Priority, IdClient) VALUES (8, 2020-01-01, 'Высокий', 1);
#Добавление нового клиента
INSERT INTO users (IdUser, LoginUser, NameUser, SurNameUser, PasswordUser, RoleId) VALUES (12, 'login', 'Имя', 'Фамилия', 'пароль', 1);
#Выбор оборудования без заявок на ремонт
SELECT e.SeriaEquipment FROM equipments e JOIN repairequipments re ON e.IdEquipment = re.IdEquipment WHERE re.IdEquipment IS NULL;
#Авторизация
SELECT * FROM users WHERE PasswordUser = '3' AND LoginUser = 'anna_sidorova';
#Редактирование причины ремонта
UPDATE equipments SET CauseEquipment = 'причина поломки' WHERE IdEquipment = 5;
UPDATE repairequipments SET Status = 3, Executor = 2 WHERE IdRepairEquipment = 1;
SELECT * FROM repairequipments WHERE IdRepair = 1;
SELECT StatusName FROM statusrepairs;
SELECT * FROM repairrequests;
SELECT * FROM repairrequests WHERE StatusRequest = '';