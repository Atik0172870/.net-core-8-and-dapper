export class Menu {
  constructor(
    public id: number,
    public name: string,
    public icon: string
  ) { }
}

export class MenuItem {
  id: number = 0;
  menuName: string = '';
  menuIcon: string = '';
  menu: Menu[] = [];

  constructor() { }
}
