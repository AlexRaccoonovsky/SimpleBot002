tag: #doc 
status: #status/going 
created:2021-06-18 10:48

# Requirements for SimpleBot001
Text verson of requirements view like:
Как вам такая задача
создать пример простого торгового робота, БЕЗ графического интерфейса. Т.е. программа написанная на C#, которая:
а) устанавливает соединение
б) проверяет что соединение установлено
в) находит инструмент и проверяет, что он нашёлся
г) получает данные с биржи
д) выставляет заявку на покупку со случайной ценой и минимальным объёмом
е) ждёт её выполнения и если не исполняется в течение 5 секунд - отменяет
ж) если заявка исполнена - выставляет заявку на продажу и ждёт, если не исполняется - отменяет
и) делает шаги г-ж в цикле (количество циклов задается в коде, скажем 5)

## DRAKON-notation
In a DRAKON-notation, algorithm can be present:
![[Pasted image 20210618210800.png]]

Summarize, task of project is create SimpleBot001 with include primary functionalities:
1) Connection+testing;
2) Find Security+test;
3) TakeData;
4) DealsMaking;
5) FinalReporting
6) Exceptions processing.

## See also
[[DesigningMOC]]

