import sys

x = sys.argv[0]

def Przyklad(x):  
	print('Parametr funkcji', x)  

	if x%2 == 0:
		x = x + 10
	else:
		x = x + 20

	print('Wynik funkcji', x)  
	return x

Przyklad(x)