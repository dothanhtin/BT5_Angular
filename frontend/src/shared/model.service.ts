import { DatePipe } from '@angular/common';
import { Injectable } from '@angular/core';
import {FormGroup,FormControl,Validators} from '@angular/forms';
import { Observable, of } from 'rxjs';
import {model} from '../app/model';
import { Guid } from "guid-typescript";
import { map } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ModelService {

  constructor(private datePipe: DatePipe,private http: HttpClient) { }
  modelList: model[]=[];
  id=Guid.EMPTY;
  imageUrl='';
  form: FormGroup = new FormGroup({
     $key: new FormControl(null), //$key : id Validators.pattern(/^[a-z]{6,32}$/i)
     id: new FormControl(this.id),
    //  code: new FormControl('',[Validators.pattern('([^+-’=]+)')]),
    code: new FormControl('',[Validators.required,Validators.pattern('^[a-zA-Z0-9_ ÆÐƎƏƐƔĲŊŒẞÞǷȜæðǝəɛɣĳŋœĸſßþƿȝĄƁÇĐƊĘĦĮƘŁØƠŞȘŢȚŦŲƯY̨Ƴąɓçđɗęħįƙłøơşșţțŧųưy̨ƴÁÀÂÄǍĂĀÃÅǺĄÆǼǢƁĆĊĈČÇĎḌĐƊÐÉÈĖÊËĚĔĒĘẸƎƏƐĠĜǦĞĢƔáàâäǎăāãåǻąæǽǣɓćċĉčçďḍđɗðéèėêëěĕēęẹǝəɛġĝǧğģɣĤḤĦIÍÌİÎÏǏĬĪĨĮỊĲĴĶƘĹĻŁĽĿʼNŃN̈ŇÑŅŊÓÒÔÖǑŎŌÕŐỌØǾƠŒĥḥħıíìiîïǐĭīĩįịĳĵķƙĸĺļłľŀŉńn̈ňñņŋóòôöǒŏōõőọøǿơœŔŘŖŚŜŠŞȘṢẞŤŢṬŦÞÚÙÛÜǓŬŪŨŰŮŲỤƯẂẀŴẄǷÝỲŶŸȲỸƳŹŻŽẒŕřŗſśŝšşșṣßťţṭŧþúùûüǔŭūũűůųụưẃẁŵẅƿýỳŷÿȳỹƴźżžẓ]*$')]),
    name: new FormControl('',[Validators.required,Validators.pattern('^[a-zA-Z0-9_]*$')]),
    birthday: new FormControl('',Validators.required),
    address: new FormControl(''),
    email: new FormControl('',[Validators.required,Validators.email]),
    image: new FormControl('',Validators.required),
  });

  initializeFormGroup(){
    this.form.setValue({
      $key:null,
      id:this.id,
      code:"",
      name:"",
      birthday:"",
      address:"",
      email:"",
      image:this.imageUrl
    });
    // this.form.clearValidators();
  }

  getModels() : Observable<model[]>{
    // let models = of(this.modelList);
    // return models;
    let URL: string = "https://localhost:44368/api/model";
        let headers = {};
    
        return this.http.get(URL).pipe(map((res:any) => {
    
            let listModels: model[] = res;
            console.log(listModels);
            return listModels;
        }));
  }

  insertModel(model:any) {
    // this.id=this.id+1;
    // this.modelList.push({
    //   id:this.id,
    //   code: model.code,
    //   name: model.name,
    //   birthday: model.birthday == "" ? "" : this.datePipe.transform(model.birthday, 'yyyy-MM-dd'),
    //   email: model.email,
    //   image: model.image,
    //   address:model.address
    // });
    // this.imageUrl='';
    // console.log(this.modelList);
    let URL = "https://localhost:44368/api/model";
    let body={
      id:this.id,
      code: model.code,
      name: model.name,
      birthday: model.birthday == "" ? "" : this.datePipe.transform(model.birthday, 'yyyy-MM-dd'),
      email: model.email,
      image: model.image,
      address:model.address
    };
    this.imageUrl='';
    this.http.post(URL, body).subscribe(
            res => {console.log(res); return res === 1 ?true:false
        });
}

updateModel(model: any) {
  // console.log(model);
 
  // let item = this.modelList.find(x => x.id == model.id);
  // console.log(item);
  // if(item!=null || item!=undefined){
  //   item.code = model.code;
  //   item.name = model.name;
  //   item.birthday = model.birthday == "" ? "" : this.datePipe.transform(model.birthday, 'yyyy-MM-dd')
  //   item.email = model.email;
  //   item.image = model.image;
  //   item.address = model.address;
  // }
  // this.imageUrl='';
  console.log(model);
  let URL = "https://localhost:44368/api/model/" + model.id;
  console.log(model);

  let body={
    code:model.code,
    name:model.name,
    birthday:model.birthday == "" ? "" : this.datePipe.transform(model.birthday, 'yyyy-MM-dd'),
    image:model.image,
    email:model.email,
    address:model.address
  };
  this.imageUrl='';

  return this.http.put(URL, body).subscribe(
    res => {console.log(res); return res === 1 ?true:false
});
}

deleteModel(id: any){
  // let index = this.modelList.findIndex(x => x.code ===code);
  // let lstmp = this.modelList.filter(item => item.code != code);
  // this.modelList = lstmp;
  // this.imageUrl='';
  let URL: string = "https://localhost:44368/api/model/" + id;
        this.http.delete(URL).subscribe(
            res => {console.log(res); return res === 1 ?true:false
        });
        this.imageUrl='';
}

populateForm(model: any) {
  this.form.setValue({
    $key:"1",
      name: model.name,
      id:model.id,
      email: model.email,
      code: model.code,
      birthday: model.birthday,
      image: model.image,
      address:model.address
  });
}
}
