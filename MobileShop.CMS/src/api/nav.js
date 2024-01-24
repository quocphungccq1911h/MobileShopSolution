import {request as Api} from './index';

export function getNav() {
    return Api.get('/NavigationMenus/GetListNavigationMenus');
}