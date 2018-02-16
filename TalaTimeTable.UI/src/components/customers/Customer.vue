<template>
  <div class="form-elements">
    <div class="row">
      <div class="col-md-12">
        <vuestic-widget :headerText="'customer.new.title' | translate">
          <form>
            <div class="row">
              <div class="col-md-6">
                <fieldset>
                  <div class="form-group">
                    <div class="input-group">
                      <input id="simple-input" required/>
                      <label class="control-label" for="simple-input">{{'customer.inputs.businessName' | translate}}</label><i class="bar"></i>
                    </div>
                  </div>
                  <div class="form-group with-icon-right"
                       :class="{'has-error': errors.has('successfulEmail'), 'valid': isSuccessfulEmailValid}">
                    <div class="input-group">
                      <input id="successfulEmail" name="successfulEmail"
                             v-model="successfulEmail" v-validate="'required|email'" required/>
                      <i class="fa fa-exclamation-triangle error-icon icon-right input-icon"></i>
                      <i class="fa fa-check valid-icon icon-right input-icon"></i>
                      <label class="control-label" for="successfulEmail">{{'customer.inputs.email'  | translate}} </label><i
                      class="bar"></i>
                      <small v-show="errors.has('successfulEmail')" class="help text-danger">
                        {{ errors.first('successfulEmail') }}
                      </small>
                    </div>
                  </div>
                </fieldset>
              </div>
              <div class="col-md-6">
                <fieldset>
                  <div class="form-group">
                    <div class="input-group">
                      <input id="simple-input" required/>
                      <label class="control-label" for="simple-input">{{'customer.inputs.address' | translate}}</label><i class="bar"></i>
                    </div>
                  </div>
                  <div class="form-group with-icon-right"
                       :class="{'has-error': errors.has('successfulPhone'), 'valid': isSuccessfulPhoneValid}">
                    <div class="input-group">
                      <input id="successfulPhone" name="successfulPhone"
                             v-model="successfulPhone" v-validate="'regex:^(\\(?\\+?[0-9]*\\)?)?[0-9_\\- \\(\\)]*$'"/>
                      <i class="fa fa-exclamation-triangle error-icon icon-right input-icon"></i>
                      <i class="fa fa-check valid-icon icon-right input-icon"></i>
                      <label class="control-label" for="successfulPhone">{{'customer.inputs.phoneNumber'  | translate}} </label><i
                      class="bar"></i>
                      <small v-show="errors.has('successfulPhone')" class="help text-danger">
                        {{ errors.first('successfulPhone') }}
                      </small>
                    </div>
                  </div>
                </fieldset>
              </div>
            </div>
            <div class="row">
              <div class="col-md-11"></div>
              <div class="col-md-1">
                <button class="btn btn-primary btn-sm">Save</button>
              </div>
            </div>
          </form>
        </vuestic-widget>
      </div>
    </div>
  </div>

</template>
<script>
export default {
  name: 'single-customer',
  computed: {
    isSuccessfulEmailValid () {
      let isValid = false
      if (this.formFields.successfulEmail) {
        isValid = this.formFields.successfulEmail.validated && this.formFields.successfulEmail.valid
      }
      return isValid
    },
    isSuccessfulPhoneValid () {
      let isValid = false
      if (this.formFields.successfulPhone) {
        console.log(this.formFields.successfulPhone.valid)
        isValid = this.formFields.successfulPhone.validated && this.formFields.successfulPhone.valid
      }
      return isValid
    }
  },
  data () {
    return {
      successfulEmail: '',
      successfulPhone: ''
    }
  }
}
</script>
