import { Component } from '@angular/core';
import { Menu, MenuItem } from './model/MenuModel/menu';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'card-access-web';

  constructor(private router: Router) { }

  public settingMenu: Menu[] = [
    new Menu(1, "System Settings", "fa fa-cog"),
    new Menu(2, "View History", "fa fa-cog"),
    new Menu(3, "Reports", "fa fa-cog"),
    new Menu(4, "Audit Trail", "fa fa-cog"),
    new Menu(5, "Service log", "fa fa-cog"),
    new Menu(6, "Company List", "fa fa-cog")
  ];

  public accessMenu: Menu[] = [
    new Menu(1, "Personnel", "fa fa-cog"),
    new Menu(2, "Badge Holder In", "fa fa-cog"),
    new Menu(3, "APB Area", "fa fa-cog"),
    new Menu(4, "Access Groups", "fa fa-cog"),
    new Menu(5, "Find Usage", "fa fa-cog"),
    new Menu(6, "Lockdown Area", "fa fa-cog"),
    new Menu(7, "Custom Fields", "fa fa-cog")
  ];

  public administrationMenu: Menu[] = [
    new Menu(1, "Badge Formats", "fa fa-cog"),
    new Menu(2, "Facility Codes", "fa fa-cog"),
    new Menu(3, "Schedule", "fa fa-cog"),
    new Menu(4, "Holidays", "fa fa-cog"),
    new Menu(5, "Setup Partition Groups", "fa fa-cog"),
    new Menu(6, "Setup Roles and Privileges", "fa fa-cog"),
    new Menu(7, "Operators", "fa fa-cog"),
    new Menu(8, "Operator Response", "fa fa-cog"),
    new Menu(9, "Operator Instructions", "fa fa-cog"),
    new Menu(10, "Operator Instructions Links", "fa fa-cog"),
    new Menu(11, "Thread Level mgmt", "fa fa-cog"),
    new Menu(12, "Facility Maps", "fa fa-cog"),
    new Menu(13, "Logged In Users", "fa fa-cog")
  ];

  public eventsandcontrols: Menu[] = [
    new Menu(1, "Event and Pending Alerts", "fa fa-cog"),
    new Menu(2, "Status", "fa fa-cog"),
    new Menu(3, "Door", "fa fa-cog"),
    new Menu(4, "Relays", "fa fa-cog"),
    new Menu(5, "Links", "fa fa-cog"),
    new Menu(6, "Activity Links", "fa fa-cog"),
    new Menu(7, "Schedule Changes", "fa fa-cog")
  ];

  public menuItem: MenuItem[] = [
    { id: 1, menuName: 'System', menuIcon: 'fa fa-cog', menu: this.settingMenu },
    { id: 2, menuName: 'Access', menuIcon: 'fa fa-universal-access', menu: this.accessMenu },
    { id: 3, menuName: 'Administration', menuIcon: 'fa fa-home', menu: this.administrationMenu },
    { id: 4, menuName: 'Event & Controls', menuIcon: 'fa fa-calendar', menu: this.eventsandcontrols }
  ];

  public trackByIndex(index: number, item: any): number {
    return index;
  }

  public navigateToPage(item: Menu): void {
    if (item.id === 1) {
      this.router.navigate(['/personnel']);
    }
  }
}
