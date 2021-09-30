import { HttpRequest, HttpClient, HttpEventType } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';

@Component({
  selector: 'app-fileupload',
  templateUrl: './fileupload.component.html',
  styles: []
})
export class FileuploadComponent implements OnInit {
  readonly baseURL;
  progress: number;
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) { this.baseURL = baseUrl; }

  ngOnInit() {
    
  }

  upload(files) {
    if (files.length === 0)
      return;

    const formData = new FormData();

    for (const file of files) {
      formData.append(file.name, file);
    }

    const uploadReq = new HttpRequest('POST', this.baseURL + 'FileManagement/upload', formData, {
      reportProgress: true,
    });

    this.http.request(uploadReq).subscribe(event => {
      if (event.type === HttpEventType.UploadProgress) {
        this.progress = Math.round(100 * event.loaded / event.total);
      };
    });
  }

}
