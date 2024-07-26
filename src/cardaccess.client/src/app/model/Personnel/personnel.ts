import { ImageLoader } from "@angular/common";

export class Personnel {
  public id: string = '';
  public firstName: string = "";
  public lastName: string = "";
  public middleName: string = "";
  public badge: number = 0;
  public facility: number = 0;
  public facilityDisplay: string = 'Not Used';
  public issue: number = 0;
  public reIssue: string = 'Ingnore Issue #';
  public enabled: boolean = false;
  public embossed: number = 0;
  public companyId: number = 0;
  public companyName: string = "";
  public badgeImage?: any[];
  public imgUrl: string = '';
}
