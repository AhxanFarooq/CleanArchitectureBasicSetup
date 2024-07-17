import { Component } from '@angular/core';
import { Contact, ContactDetailModel, ContactCoversationModel } from '../company.component';
import { SetupService } from 'src/app/services/setup.service';
import { Area } from 'src/app/Setup/area/area.component';
import { Industry } from 'src/app/Setup/industry/industry.component';
import { CompanyService } from 'src/app/services/company.service';
import { ActivatedRoute, Router } from '@angular/router';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-add-company',
  templateUrl: './add-company.component.html',
  styleUrls: ['./add-company.component.css']
})
export class AddCompanyComponent {
  activeTab: string = 'tab1';
  areas: Area[] = [];
  industrys: Industry[] = [];
  newContact: Contact = new Contact();
  editCustomerId: string = '';
  isEdit: boolean = false;
  pageIndex = 0;
  totalPages = 0;
  cities: string[] = [
    'Islamabad',
    'Ahmed Nager Chatha',
    'Ahmadpur East',
    'Ali Khan Abad',
    'Alipur',
    'Arifwala',
    'Attock',
    'Bhera',
    'Bhalwal',
    'Bahawalnagar',
    'Bahawalpur',
    'Bhakkar',
    'Burewala',
    'Chillianwala',
    'Chakwal',
    'Chichawatni',
    'Chiniot',
    'Chishtian',
    'Daska',
    'Darya Khan',
    'Dera Ghazi Khan',
    'Dhaular',
    'Dina',
    'Dinga',
    'Dipalpur',
    'Faisalabad',
    'Ferozewala',
    'Fateh Jang',
    'Ghakhar Mandi',
    'Gojra',
    'Gujranwala',
    'Gujrat',
    'Gujar Khan',
    'Hafizabad',
    'Haroonabad',
    'Hasilpur',
    'Haveli Lakha',
    'Jatoi',
    'Jalalpur',
    'Jattan',
    'Jampur',
    'Jaranwala',
    'Jhang',
    'Jhelum',
    'Kalabagh',
    'Karor Lal Esan',
    'Kasur',
    'Kamalia',
    'Kamoke',
    'Khanewal',
    'Khanpur',
    'Kharian',
    'Khushab',
    'Kot Addu',
    'Jauharabad',
    'Lahore',
    'Lalamusa',
    'Layyah',
    'Liaquat Pur',
    'Lodhran',
    'Malakwal',
    'Mamoori',
    'Mailsi',
    'Mandi Bahauddin',
    'Mian Channu',
    'Mianwali',
    'Multan',
    'Murree',
    'Muridke',
    'Mianwali Bangla',
    'Muzaffargarh',
    'Narowal',
    'Nankana Sahib',
    'Okara',
    'Renala Khurd',
    'Pakpattan',
    'Pattoki',
    'Pir Mahal',
    'Qaimpur',
    'Qila Didar Singh',
    'Rabwah',
    'Raiwind',
    'Rajanpur',
    'Rahim Yar Khan',
    'Rawalpindi',
    'Sadiqabad',
    'Safdarabad',
    'Sahiwal',
    'Sangla Hill',
    'Sarai Alamgir',
    'Sargodha',
    'Shakargarh',
    'Sheikhupura',
    'Sialkot',
    'Sohawa',
    'Soianwala',
    'Siranwali',
    'Talagang',
    'Taxila',
    'Toba Tek Singh',
    'Vehari',
    'Wah Cantonment',
    'Wazirabad',
    'Badin',
    'Bhirkan',
    'Rajo Khanani',
    'Chak',
    'Dadu',
    'Digri',
    'Diplo',
    'Dokri',
    'Ghotki',
    'Haala',
    'Hyderabad',
    'Islamkot',
    'Jacobabad',
    'Jamshoro',
    'Jungshahi',
    'Kandhkot',
    'Kandiaro',
    'Karachi',
    'Kashmore',
    'Keti Bandar',
    'Khairpur',
    'Kotri',
    'Larkana',
    'Matiari',
    'Mehar',
    'Mirpur Khas',
    'Mithani',
    'Mithi',
    'Mehrabpur',
    'Moro',
    'Nagarparkar',
    'Naudero',
    'Naushahro Feroze',
    'Naushara',
    'Nawabshah',
    'Nazimabad',
    'Qambar',
    'Qasimabad',
    'Ranipur',
    'Ratodero',
    'Rohri',
    'Sakrand',
    'Sanghar',
    'Shahbandar',
    'Shahdadkot',
    'Shahdadpur',
    'Shahpur Chakar',
    'Shikarpaur',
    'Sukkur',
    'Tangwani',
    'Tando Adam Khan',
    'Tando Allahyar',
    'Tando Muhammad Khan',
    'Thatta',
    'Umerkot',
    'Warah',
    'Abbottabad',
    'Adezai',
    'Alpuri',
    'Akora Khattak',
    'Ayubia',
    'Banda Daud Shah',
    'Bannu',
    'Batkhela',
    'Battagram',
    'Birote',
    'Chakdara',
    'Charsadda',
    'Chitral',
    'Daggar',
    'Dargai',
    'Darya Khan',
    'Dera Ismail Khan',
    'Doaba',
    'Dir',
    'Drosh',
    'Hangu',
    'Haripur',
    'Karak',
    'Kohat',
    'Kulachi',
    'Lakki Marwat',
    'Latamber',
    'Madyan',
    'Mansehra',
    'Mardan',
    'Mastuj',
    'Mingora',
    'Nowshera',
    'Paharpur',
    'Pabbi',
    'Peshawar',
    'Saidu Sharif',
    'Shorkot',
    'Shew'
  ]

  constructor(private setupService: SetupService, private router: Router,
    private contactService: CompanyService, private route: ActivatedRoute) {
    this.route.queryParams.subscribe(params => {
      this.editCustomerId = params['data'];
      if (this.editCustomerId != undefined) {
        this.isEdit = true;
        this.getContactById()
      }

    });
  }
  ngOnInit(): void {

    this.fetchAreas();
    this.fetchIndustrys();
    // Initialize areas array with sample data or fetch from a service
  }
  fetchAreas() {
    this.setupService.GetAll("Area", this.pageIndex, this.totalPages).subscribe({
      next: (response) => {

        this.areas = response.items.map((area: Area) => ({
          id: area.id,
          name: area.name,
          description: area.description,
          isActive: area.isActive
        }))
        // Handle response, store token, navigate or display a message
      },
      error: (error) => {
        Swal.fire({
          title: 'Something went wrong?',
          text: error,
          icon: 'error'
        })
        // Handle error
      }
    });
  }
  fetchIndustrys() {
    this.setupService.GetAll("Industry", this.pageIndex, this.totalPages).subscribe({
      next: (response) => {

        this.industrys = response.items.map((industry: Industry) => ({
          id: industry.id,
          name: industry.name,
          description: industry.description,
          isActive: industry.isActive
        }))
        // Handle response, store token, navigate or display a message
      },
      error: (error) => {
        Swal.fire({
          title: 'Something went wrong?',
          text: error,
          icon: 'error'
        })
        // Handle error
      }
    });
  }
  getContactById() {
    this.contactService.GetById(this.editCustomerId).subscribe({
      next: (response) => {
        this.newContact = response;
      },
      error: (error) => {
        Swal.fire({
          title: 'Something went wrong?',
          text: error,
          icon: 'error'
        })
        // Handle error
      }
    });
  }
  SaveChanges() {
    this.contactService.Create(this.newContact).subscribe({
      next: () => {
        Swal.fire({
          title: "Saved!",
          text: "Date saved successfully!",
          icon: "success"
        });
        this.newContact = new Contact();
        // Handle response, store token, navigate or display a message
      },
      error: (error) => {
        Swal.fire({
          title: 'Something went wrong?',
          text: error,
          icon: 'error'
        })
      }
    });
  }
  NavigateToList() {
    Swal.fire({
      title: 'Are you sure?',
      text: 'You will not be able to recover.!',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Yes, cancel it!',
      cancelButtonText: 'No, keep it'
    }).then((result) => {
      if (result.value) {
        Swal.fire(
          'Navigate!',
          'Navigate to list page.',
          'success'
        )
        this.router.navigate(['/contact']);
      } else if (result.dismiss === Swal.DismissReason.cancel) {
        Swal.fire(
          'Cancelled',
          'Your page is safe :)',
          'error'
        )
      }
    });
    
  }
  UpdateChanges() {
    this.contactService.Update(this.newContact).subscribe({
      next: () => {
        Swal.fire({
          title: "Updated!",
          text: "Date updated successfully!",
          icon: "success"
        });
        this.router.navigate(['/contact']);
        // Handle response, store token, navigate or display a message
      },
      error: (error) => {
        Swal.fire({
          title: 'Something went wrong?',
          text: error,
          icon: 'error'
        })
        // Handle error
      }
    });
  }

  addConversationField() {
    this.newContact.contactCoversationModels.push(new ContactCoversationModel());
  }

  removeConversationField(index: number) {
    this.newContact.contactCoversationModels.splice(index, 1);
  }

  addContactDetailField() {
    this.newContact.contactDetailModels.push(new ContactDetailModel());
  }

  removeContactDetailField(index: number) {
    this.newContact.contactDetailModels.splice(index, 1);
  }

}
