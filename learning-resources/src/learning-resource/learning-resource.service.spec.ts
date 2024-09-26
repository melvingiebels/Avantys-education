import { Test, TestingModule } from '@nestjs/testing';
import { LearningResourceService } from './learning-resource.service';

describe('LearningResourceService', () => {
  let service: LearningResourceService;

  beforeEach(async () => {
    const module: TestingModule = await Test.createTestingModule({
      providers: [LearningResourceService],
    }).compile();

    service = module.get<LearningResourceService>(LearningResourceService);
  });

  it('should be defined', () => {
    expect(service).toBeDefined();
  });
});
