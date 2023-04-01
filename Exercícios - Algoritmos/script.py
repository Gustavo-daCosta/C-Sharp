import os

for c in range(1, 101):
  if c < 10:
    path = f"00{c}"
  elif c < 100: 
    path = f"0{c}"
  else:
    path = f"{c}"

  os.mkdir(path)
  os.chdir(path=path)
  os.system("dotnet new console")
  os.chdir(path="..")
