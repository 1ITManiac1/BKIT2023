import json
import sys
# ������� ��㣨� ����室��� �������

path = None

# ����室��� � ��६����� path ��࠭��� ���� � 䠩��, ����� �� ��।�� �� ����᪥ �業���

with open(path) as f:
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


if __name__ == '__main__':
    with cm_timer_1():
        f4(f3(f2(f1(data))))