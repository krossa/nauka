import { User } from '../user.model';
import * as AuthActions from './auth.actions';
import { ActionsSubject } from '@ngrx/store';

export interface State {
  authError: string;
  loading: boolean;
  user: User;
}

const initialState: State = {
  authError: null,
  loading: false,
  user: null
};

export function authReducer(state = initialState, action: AuthActions.AuthActions) {
  switch (action.type) {
    case AuthActions.LOGIN_START:
    case AuthActions.SIGNUP_START:
      return {
        ...state,
        authError: null,
        loading: true
      };
    case AuthActions.AUTHENTICATE_SUCCESS:
      const user = new User(action.payload.email, action.payload.userId, action.payload.token, action.payload.expirationDate);
      return {
        ...state,
        authError: null,
        loading: false,
        user
      };
    case AuthActions.AUTHENTICATE_FAIL:
      return {
        ...state,
        authError: action.payload,
        loading: false,
        user: null
      };
    case AuthActions.LOGOUT:
      return {
        ...state,
        user: null
      };
    case AuthActions.CLEAR_ERROR:
      {
        return {
          ...state,
          authError: null
        };
      }
    default: return state;
  }
}
