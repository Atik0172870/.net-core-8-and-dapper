import { Component, OnInit } from '@angular/core';
import { Personnel } from '../model/Personnel/personnel';
import { PersonnelService } from '../services/personnelService/personnel.service';
import { PersonnelClient } from '../web-api-client';
import { DomSanitizer, SafeResourceUrl, SafeUrl } from '@angular/platform-browser';

@Component({
  selector: 'app-personnel',
  templateUrl: './personnel.component.html',
  styleUrls: ['./personnel.component.scss']
})
export class PersonnelComponent implements OnInit {

  badgeList: Array<Personnel> = new Array<Personnel>();
  public selectedBadge: Personnel = new Personnel();


  constructor(private service: PersonnelService) { }

  ngOnInit(): void {
    this.getBadge();
  }

  // public personnelList: Array<Personnel> = [
  //   new Personnel(1, 'CAhtear', 'CRahman', 'Ahtear Customer Company', '99888'),
  //   new Personnel(2, 'John', 'Doe', 'Ahtear Company', '3987'),
  //   new Personnel(3, 'Ahtear', 'Rahman', 'ACompany', '3882'),
  //   new Personnel(4, 'WICK', 'JHON', 'AAhtear Company', '3987'),
  //   new Personnel(5, 'CAhtear', 'CRahman', 'Ahtear Customer Company', '3986'),
  //   new Personnel(6, 'Assad', '', 'zaman', '99888'),
  //   new Personnel(7, 'CAhtear', 'CRahman', 'Ahtear tCompany', '99888'),
  //   new Personnel(8, 'CAhtear', 'CRahman', 'Ahtear rCompany', '00000')
  // ];
  getBadge = () => {
    let sub = this.service.getBadges().subscribe(
      {
        next: (dataList: Array<Personnel>) => {
          console.log(dataList);
         this.onPersonnelSelect(dataList[0]);
          this.badgeList = dataList;
        },
        error: (e) => console.error(e),
        complete: () => {
          console.info('complete');
          sub.unsubscribe();
        }
      }
    )
  }


  onPersonnelSelect = (personnel: Personnel) => {
    this.selectedBadge = personnel;
    this.selectedBadge.facilityDisplay = this.selectedBadge.facility ? this.selectedBadge.facility.toString() : 'Not Used';
    this.selectedBadge.reIssue = this.selectedBadge.issue ? this.selectedBadge.issue.toString() : 'Ingnore Issue #';
    this.selectedBadge.imgUrl = 'data:image/jpeg;base64,' + this.selectedBadge.badgeImage;
    //this.makeImage(this.selectedBadge.badgeImage);
  }

}
