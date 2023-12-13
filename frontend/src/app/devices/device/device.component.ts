import { Component, Input } from '@angular/core';
import { Device } from '../devices.types';

@Component({
  selector: 'app-device',
  templateUrl: './device.component.html',
  styleUrls: ['./device.component.scss']
})
export class DeviceComponent {
  @Input()
  public set device(device: Device) {
    this._device = device;
    this.formatedDate = this.formatDate('2023-05-12');
  };

  public get device(): Device {
    return this._device;
  }

  private formatedDate: string;
  private _device: Device;

  private formatDate(dateString: Date): string {
    return dateString.toLocaleDateString();
  }
}
