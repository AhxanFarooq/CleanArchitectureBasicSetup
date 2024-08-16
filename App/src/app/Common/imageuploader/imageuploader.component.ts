import { Component, ElementRef, EventEmitter, Input, OnInit, Output, SimpleChanges, ViewChild } from '@angular/core';
import { SetupService } from 'src/app/services/setup.service';

@Component({
  selector: 'app-imageuploader',
  templateUrl: './imageuploader.component.html',
  styleUrls: ['./imageuploader.component.css']
})
export class ImageuploaderComponent {

  @Output() onImageUploadEvent = new EventEmitter<{name:string,type:string,value:any}>();
  @Input() filePath: string = '';
  @Input() name: string = '';
  @Input() type: string = 'image';
  base64Path: any = null;
  @ViewChild('fileInput') fileInput: ElementRef<HTMLInputElement> | undefined;
  imageSrc: string | ArrayBuffer | null = 'assets\\images\\upload.png';



  constructor(private setupService: SetupService) {

  }
  ngOnChanges(changes: SimpleChanges) {
    if (changes['filePath']) {
      //const previousValue = changes['filePath'].previousValue;
      const currentValue = changes['filePath'].currentValue;
      if(currentValue){
        this.getBase64ImagePath();
      }
    }
  }
  
  // Method to simulate a click on the hidden file input
  onImageClick() {
    this.fileInput?.nativeElement.click();
  }

  // Method to handle the file selection
  onFileSelected(event: Event) {
    this.base64Path = null;
    const input = event.target as HTMLInputElement;
    if (input.files) {
      const file = input.files[0];
      var fileData = new FormData();
      for (var k = 0; k < input.files.length; k++) {
        fileData.append("files", input.files[k]);
      }
      this.setupService.ImageUploader('ImageUploader', fileData).subscribe({
        next: (response) => {
          this.filePath = response.message;
          this.onUploadImage(response.message)
          if (file) {
            const reader = new FileReader();
            reader.onload = () => {
              this.imageSrc = reader.result;
            };
            reader.readAsDataURL(file);
          }
        },
        error: (error) => {
          console.log(error);
        }
      });


      
    }

  }
  getBase64ImagePath() {
    this.setupService.GetBase64Image('ImageUploader', this.filePath).subscribe({
      next: (response) => {
        this.base64Path = response.message
      },
      error: (error) => {
        console.log(error)
      }
    })
  }

  deleteImage(event: MouseEvent): void {
    event.stopPropagation(); // Stop propagation to prevent opening the file input
    this.imageSrc = 'assets\\images\\upload.png'; // Clear the image source
  }
  onUploadImage(path:string){
    this.onImageUploadEvent.emit({name: this.name, type: this.type ,value:path})
   }

}

