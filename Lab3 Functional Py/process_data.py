import json 
from pathlib import *
from sys import *
from cm_timer import *
from field import *
from gen_random import *
from print_result import *
from sort import *
from unique import *
import os

with open('data_light.json', 'r') as f:
    data = json.load(f)

# ����� ����室��� ॠ�������� �� �㭪樨 �� �������, ������� `raise NotImplemented`
# �।����������, �� �㭪樨 f1, f2, f3 ���� ॠ�������� � ���� ��ப�
# � ॠ����樨 �㭪樨 f4 ����� ���� �� 3 ��ப

@print_result
def f1(arg):
    raise NotImplemented


@print_result
def f2(arg):
    raise NotImplemented


@print_result
def f3(arg):
    raise NotImplemented


@print_result
def f4(arg):
    raise NotImplemented

def main():
    with cm_timer_1():
        f4(f3(f2(f1(data))))

if __name__ == '__main__':
    main()