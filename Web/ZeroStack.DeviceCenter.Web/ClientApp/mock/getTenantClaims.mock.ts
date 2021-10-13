// @ts-ignore
import { Request, Response } from 'express';

export default {
  'GET /api/TenantClaims/{tenantId}': (req: Request, res: Response) => {
    res.status(200).send([
      {
        id: 88,
        tenantId: 'b92cbE6c-BB1B-eAFE-EF1f-D388b4fB7447',
        claimType: 1,
        claimValue: '约产电且产每况南引以识交部社是即。',
      },
      {
        id: 90,
        tenantId: '2e2ADe6d-DEdE-f355-AfEb-514EAfbbAAeF',
        claimType: 2,
        claimValue: '种马温二感改位当斗共气红身县。',
      },
      {
        id: 81,
        tenantId: 'dA48DAd4-2D3f-Aedb-5582-84B8cBe115B3',
        claimType: 3,
        claimValue: '候特再打圆关起类低完设又制反步。',
      },
      {
        id: 72,
        tenantId: '09ED62fA-A173-CB8C-473f-b2dB13ADcC40',
        claimType: 4,
        claimValue: '然之认连众声京相路两传影圆难。',
      },
      {
        id: 62,
        tenantId: 'B9CBE4ec-c552-2af8-28BD-b8C4E15cCFfA',
        claimType: 5,
        claimValue: '容石京复至已酸快果长示称其外图研。',
      },
      {
        id: 75,
        tenantId: 'ccC2D3Fd-c7df-AFfB-BA2b-DBE115A12683',
        claimType: 6,
        claimValue: '习克不从什别深口音团她大权整就目验究。',
      },
      {
        id: 72,
        tenantId: 'BCe4C72e-aFAa-fE8a-d05D-3c8596bfc8cf',
        claimType: 7,
        claimValue: '意打数效须称和或接统统取包则。',
      },
      {
        id: 82,
        tenantId: '0e43CDc9-d6A7-9A92-3Dc5-6EED1B7ABEA4',
        claimType: 8,
        claimValue: '信质即报完法验变常改组由比可用林。',
      },
      {
        id: 74,
        tenantId: 'B2E5fA2a-b4B0-46f8-977c-8c9649C59CA4',
        claimType: 9,
        claimValue: '听石志每小放南火运个商原特。',
      },
      {
        id: 69,
        tenantId: 'fD24b742-DEF1-c8cA-7b0f-FD33BFFE7efA',
        claimType: 10,
        claimValue: '内管造农种使花边济院热改走查须并。',
      },
    ]);
  },
  'GET /api/TenantClaims': (req: Request, res: Response) => {
    res.status(200).send([
      {
        id: 82,
        tenantId: 'dEEC69ad-f12b-FA45-6fC1-f09f5eC618e2',
        claimType: 11,
        claimValue: '议存据总周需流素养流情子。',
      },
      {
        id: 93,
        tenantId: '2CdFdA88-92Da-f4FC-9924-cC9DeBdfDBF7',
        claimType: 12,
        claimValue: '了果工较部约非儿组料更整车。',
      },
      {
        id: 86,
        tenantId: 'bbceAFDF-cA7F-b1ad-C93E-eCaE460A7EFf',
        claimType: 13,
        claimValue: '好己始别量院领非音速关他王因口层点等。',
      },
      {
        id: 85,
        tenantId: 'f15cF7D7-Df1a-e68A-0fdc-DA35dDFf4507',
        claimType: 14,
        claimValue: '转准容型能直实性速建小用可南。',
      },
    ]);
  },
};
