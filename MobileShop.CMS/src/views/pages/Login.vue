<template>
    <div class="bg-light min-vh-100 d-flex flex-row align-items-center">
        <CContainer>
            <CRow class="justify-content-center">
                <CCol :md="8">
                    <CCardGroup>
                        <CCard class="p-4">
                            <CCardBody>
                                <CForm>
                                    <h1>Đăng nhập</h1>
                                    <p class="text-medium-emphasis">Đăng nhập vào tài khoản của bạn
                                    </p>
                                    <CInputGroup class="mb-3">
                                        <CInputGroupText>
                                            <CIcon icon="cil-user" />
                                        </CInputGroupText>
                                        <CFormInput placeholder="Tài khoản" autocomplete="username" />
                                    </CInputGroup>
                                    <CInputGroup class="mb-4">
                                        <CInputGroupText>
                                            <CIcon icon="cil-lock-locked" />
                                        </CInputGroupText>
                                        <CFormInput type="password" placeholder="Mật khẩu"
                                            autocomplete="current-password" />
                                    </CInputGroup>
                                    <CRow>
                                        <CCol :xs="6">
                                            <CButton color="primary" class="px-4"> Đăng nhập </CButton>
                                        </CCol>
                                        <CCol :xs="6" class="text-right">
                                            <CButton color="link" class="px-0">
                                                Quên mật khẩu?
                                            </CButton>
                                        </CCol>
                                    </CRow>
                                </CForm>
                            </CCardBody>
                        </CCard>
                        <CCard class="text-white bg-primary py-5" style="width: 44%">
                            <CCardBody class="text-center">
                                <div>
                                    <h2>Đăng ký</h2>
                                    <p>
                                        Nếu bạn chưa có tài khoản. Hãy đăng ký một tài khoản!
                                    </p>
                                    <CButton color="light" variant="outline" class="mt-3">
                                        Đăng ký ngay!
                                    </CButton>
                                </div>
                            </CCardBody>
                        </CCard>
                    </CCardGroup>
                </CCol>
            </CRow>
        </CContainer>
    </div>
</template>
<script>
export default {
    name: 'Login',
}
</script>