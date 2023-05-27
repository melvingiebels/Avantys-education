import { Test, TestingModule } from '@nestjs/testing';
import { GuidanceTalkService } from './guidance-talk.service';

describe('GuidanceTalkService', () => {
  let service: GuidanceTalkService;

  beforeEach(async () => {
    const module: TestingModule = await Test.createTestingModule({
      providers: [GuidanceTalkService],
    }).compile();

    service = module.get<GuidanceTalkService>(GuidanceTalkService);
  });

  it('should be defined', () => {
    expect(service).toBeDefined();
  });
});
